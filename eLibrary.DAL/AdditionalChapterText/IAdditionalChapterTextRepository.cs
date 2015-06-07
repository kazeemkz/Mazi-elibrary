﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibrary.DAL
{
    public interface IAdditionalChapterTextRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
    }
}
