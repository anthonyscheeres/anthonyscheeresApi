﻿namespace ChantemerleApi.Models
{

    public static class DataModel
    {
        public static ConfigModel config = new ConfigModel();


        public static void set(ConfigModel config)
        {
            DataModel.config = config;
        }

        public static ConfigModel get()
        {
            return config;
        }

    }
}
