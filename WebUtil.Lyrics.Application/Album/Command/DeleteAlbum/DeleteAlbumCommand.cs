﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Albums.Command.DeleteAlbum
{
	public record DeleteAlbumCommand(string albumcode):IRequest<DeleteAlbumResult>;
}
