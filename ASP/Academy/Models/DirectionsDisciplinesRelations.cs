using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models;

//PJT - Pure Join Table
[PrimaryKey(nameof(direction), nameof(discipline))]
public class DirectionsDisciplinesRelations
{
	[ForeignKey("Direction")]
	public byte direction { get; set; }
	[ForeignKey("Discipline")]
	public short discipline { get; set; }

	//Navigation properties:
	public required Direction Direction { get; set; }
	public required Discipline Discipline { get; set; }
}
