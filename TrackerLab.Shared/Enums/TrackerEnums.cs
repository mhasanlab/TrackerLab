﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Enums
{
    public enum IssuePriority
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }

    public enum IssueStatus
    {
        Open = 0,
        InProgress = 1,
        Resolved = 2
    }

    public enum IssueSortBy
    {
        Priority,
        Title
    }

}
