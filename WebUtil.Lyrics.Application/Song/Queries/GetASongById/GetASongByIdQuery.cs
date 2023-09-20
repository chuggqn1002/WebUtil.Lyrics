﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Songs.Queries.GetASongById
{
    public record GetASongByIdQuery(
        
        Guid Suid
        
        ):IRequest<GetASongByIdResult>;
    
}