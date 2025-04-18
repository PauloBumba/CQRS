﻿using System.ComponentModel.DataAnnotations;
using CQRS.Models;
namespace CQRS.Command
{
	public class CreateProductCommand
	{
		[Required (ErrorMessage ="Nome do produto é obrigatório")]
		[StringLength(100)]
		public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Nome do preço é obrigatório")]
        public string Price { get; set; } = string.Empty;
	}
}