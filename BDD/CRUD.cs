using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson; ///Utilise pour le ObjectId


namespace Tests
{
    public class MongoCRUD /*modification functions for Mongo*/
    {
        /*cette classe est une librairie de plusieurs fonctions permettant de communiquer avec des bases de donnees mongo depuis C#. Outils de creation de collections, outils de modification d'objets, outils de suppression, outils de recherche*/
        /*this class is a library of several functions allowing to communicate with Mongo databases from C#. Collections creation tools, object modification tools, deletion tools, search tools*/
        private IMongoDatabase db;

        public MongoCRUD(IMongoDatabase f_db)
        { /*connecte à database ou cree la base du nom de database */
        /*connects to database or creates database name database*/
            db = f_db;
        }

        public void InsertRecord<T>(string table, T record)
        { /*ajouter un element record (de classe T ) dans une collection table, si table inexistant creation automatique */
            /*add a record element (class T ) in a table collection, if no table automatic creation*/
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> LoadRecords<T>(string table)
        {  /*lire une collection entiere*/
            /*lire une collection entiere*/
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, ObjectId id)
        { /*chercher l'element de la collection table grace a son id */
            /*search for the item of the table collection thanks to its id*/
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return collection.Find(filter).First();
        }

        public void UpsetRecord<T>(string table, ObjectId id, T record)
        { /*changer l'element id dans une collection par l'element record. Il est possible de remplacer une seule propriete de l'element */
            /*change the element id in a collection by the element record. It is possible to replace a single property of the element*/
            var collection = db.GetCollection<T>(table);
            var result = collection.ReplaceOne(
             new BsonDocument("_id", id),
             record,
             new UpdateOptions { IsUpsert = true });
        }

        public void DeleteRecord<T>(string table, ObjectId id)
        { /*supprimer un element identifie par son id */
            /*delete an element identified by its id*/
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }

        public List<T> LoadRecordByParameterString<T,Q>(string table, string parameter, Q parameterValue)
        { /*chercher les elements de la collection table grace a la valeur de l'un de ses parametres en Q */
            /*search the elements of the table collection thanks to the value of one of its parameters in Q*/
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(parameter, parameterValue);
            return collection.Find(filter).ToList();
        }

        public List<T> LoadRecordInferiorStrictParameterInt<T,Q>(string table, string parameter, Q parameterValue)
        { /*cherche les elements de la collection qui ont un parametre inferieur strictement a un seuil en Q*/
            /*searches for items in the collection that have a parameter that is strictly inferior to a threshold in Q*/
            var collection = db.GetCollection<T>(table);
            var filter= Builders<T>.Filter.Lt(parameter, parameterValue);
            return collection.Find(filter).ToList();
        }

        public List<T> LoadRecordInferiorEqualParameter<T,Q>(string table, string parameter, Q parameterValue)
        { /*cherche les elements de la collection qui ont un parametre inferieur ou egal a un seuil en Q*/
            /*searches for items in the collection that have a parameter lower than or equal to a threshold in Q*/
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Lte(parameter, parameterValue);
            return collection.Find(filter).ToList();
        }

        public List<T> LoadRecordSuperiorStrictParameter<T,Q>(string table, string parameter, Q parameterValue)
        { /*cherche les elements de la collection qui ont un parametre superieur strictement a un seuil en Q*/
            /*searches for items in the collection that have a parameter that is higher than a threshold in Q*/
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Gt(parameter, parameterValue);
            return collection.Find(filter).ToList();
        }

        public List<T> LoadRecordSuperiorEqualParameter<T,Q>(string table, string parameter, Q parameterValue)
        { /*cherche les elements de la collection qui ont un parametre superieur ou egal a un seuil en Q*/
            /*searches for items in the collection that have a higher or egal parameter at an Q threshold*/
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Gte(parameter, parameterValue);
            return collection.Find(filter).ToList();
        }


    }
}