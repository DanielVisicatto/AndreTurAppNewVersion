﻿namespace AndreTurApp.Models
{
    public class City
    {
        #region[Properties]
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion

        #region[Ctor]        
       // public City()
        //{
        //    RegisterDate = DateTime.Now;
        //}
        #endregion

    }
}