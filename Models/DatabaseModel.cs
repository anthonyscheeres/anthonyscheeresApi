﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Models
{
	public class DatabaseModel
	{
		public string cs { get; }
		public DatabaseModel(string cs)
		{
			this.cs = cs;
		}
	}
}
