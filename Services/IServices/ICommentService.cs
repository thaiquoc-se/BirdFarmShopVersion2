﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICommentService
    {
        List<TblComment> GetAllCommnets();
        void AddNew(TblComment comment);
    }
}
