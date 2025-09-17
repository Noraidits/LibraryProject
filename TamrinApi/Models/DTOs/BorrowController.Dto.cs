namespace TamrinApi.Models.DTOs
{


	public record BorrowGetDto(

		Guid id,
		Guid bookid,
		Guid memberid,
		DateOnly borrowDate,
		DateOnly shouldReturnDate,
		DateOnly returnDate
	);

	public record BorrowPostDto(
		Guid Bookid,
		Guid Memberid
	);

}

//Guid id
//Guid bookid
//Guid memberid
//DateOnly borrowDate 
//DateOnly shouldReturnDate
//DateOnly returnDate