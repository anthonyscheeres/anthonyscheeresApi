﻿using AnthonyscheeresApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;


namespace AnthonyscheeresApi.Utilities 
{
     internal class ConfigFileInDocumetsFolderUtililities
    {

         string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/AnthonyScheeresServer/";
        string filename = "config.json";

        public ConfigFileInDocumetsFolderUtililities(string path, string filename)
        {
            this.path = path;
            this.filename = filename;
        }

        internal void writeDataModelToJsonFileInDocumetsFolder()
        {
            //Construct path to file
            string pathToFile = path + filename;
           

            //Defeault config model
            ConfigModel dataForDefaultConfigModel = new ConfigModel(
                new DatabaseModel("Host=*******;Username=****;Password=****; Database=****"), 
                new MailModel("****@gmail.com", "****", "smtp.gmail.com"), //email for validation of a users email 
                new RestApiModel(44314, "localhost", true) //this is needed so the token system can call itself
);




            // If the directory doesn't exist, create it.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

               //Object to indented json string 
                string json = JsonConvert.SerializeObject(dataForDefaultConfigModel, Formatting.Indented);


                //Write the json string to a file
                File.WriteAllText(pathToFile, json);

            }

            //read file from directory to object
            ConfigModel configTemp = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(pathToFile));

            //Overwrite the static config model 
            DataModel.setConfigModel(configTemp);

           
        }


    



    }





}

