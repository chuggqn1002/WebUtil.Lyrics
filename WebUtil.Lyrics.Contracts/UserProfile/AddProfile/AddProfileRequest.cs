﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.UserProfile.AddProfile
{
    public record AddProfileRequest
    (
        string FirstName,
        string LastName,
        string Middle,
        string Title,
        string Address,
        string Ward,
        string District,
        string City,
        string Country,
        string ZipCode,
        DateTime Birthdate,
        string Avatar,
        int Gender,
        string TelNum,
        string Description,
        int Status,
        DateTime Created,
        DateTime Updated
    );
}
