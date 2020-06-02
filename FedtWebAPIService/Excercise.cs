namespace FedtWebAPIService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Excercise")]
    public partial class Excercise
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Excercise_ID { get; set; }

        [StringLength(50)]
        public string ExName { get; set; }

        public int? Length { get; set; }

        public int? Equipment_ID { get; set; }

        public int? Muscles_ID { get; set; }

        public string Image { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
