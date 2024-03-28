using Forest.Data.IDAO;
using Forest.Data.Models.Domain;
using Forest.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forest.Data.DAO
{
    public class MusicDAO : IMusicDAO
    {
        //ForestContext context;
        //public MusicDAO()
        //{
        //    context = new ForestContext();
        //}
        public Music GetMusic(int id, ForestContext context)
        {
            Music music = new Music();
            music = context.Musics.Find(id);
            return music;
        }
        public void AddMusic(Music music, ForestContext context) 
        {
            context.Musics.Add(music);
        }
        public void DeleteMusic(Music music, ForestContext context)
        {
            context.Musics.Remove(music);
        }
        public void UpdateMusic(Music music, ForestContext context)
        {
            Music m = context.Musics.Find(music.Id);
            context.Entry(m).CurrentValues.SetValues(music);
        }
        public void AddToCollection(OrderLine orderLine, int musicId, ForestContext context)
        {
            Music music = context.Musics.Find(musicId);
            if (music != null) 
            {
                music.OrderLines.Add(orderLine);
            }
        }
    }
}
