﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransaction.Domain.Interfaces
{
    public interface ITransaction
    {
        void SaveAllChanges();
    }
}
