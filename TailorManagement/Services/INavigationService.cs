﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagement.Services
{
    public interface INavigationService
    {
        void NavigateTo(Type viewType);
    }
}
