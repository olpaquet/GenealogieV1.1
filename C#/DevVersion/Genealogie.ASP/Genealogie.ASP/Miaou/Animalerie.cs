using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Genealogie.ASP.Models;
using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using Microsoft.AspNet.SignalR;

namespace Genealogie.ASP.Miaou
{
    public class Animalerie : Hub
    {
        public void Envoyer(string message)
        {
            int uId = SessionUtilisateur.Utilisateur.id;
            Clients.All.ajouterMessage(message);
            new ChatServiceAPI().Creer(new Chat {message=message, id=uId });
        }
    }
}