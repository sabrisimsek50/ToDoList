$("#AddToDoList").submit(function (e) {
	e.preventDefault();

	$.ajax({
		url: "/Home/Add",
		dataType: "json",
		type: "post",
		data: new FormData($('form')[0]),
		processData: false,
		contentType: false,
		success: function (data) {
			if (data != null || data != 'undefined') {
				window.location.href = "/Home/Index"
			}
			else {
				alert("Error!!!")
			}

		}
	})
})

function DeleteToDoList(id) {
	swal({
		title: 'Delete To Do List',
		text: "Are you sure you want to delete?",
		type: 'warning',
		showCancelButton: true,
		confirmButtonColor: "#DD6B55",
		confirmButtonText: "CONFIRM",
		cancelButtonText: "CANCEL",
		closeOnConfirm: false,
		closeOnCancel: false
	}).then(function (isConfirm) {
		if (isConfirm) {
			$.ajax({
				url: "/Home/Delete",
				datatype: "Json",
				type: "Post",
				data: { id: id },
				success: function (data) {
					if (data) {
						swal({
							type: "success",
							text: "Deleted"

						});

						window.location.reload();
					}
					else {
						swal({
							type: "success",
							text: data.Message
						});
						return false;
					}
				}
			});

		}
	});
}


$("#UpdateToDoList").submit(function (e) {
	e.preventDefault();

	$.ajax({
		url: "/Home/Update",
		dataType: "json",
		type: "post",
		data: new FormData($('form')[0]),
		processData: false,
		contentType: false,
		success: function (data) {
			if (data != null || data != 'undefined') {
				window.location.href = "/Home/Index"
			}
			else {
				alert("Error!!!")
			}

		}
	})
})


$(function () {
	var dtToday = new Date();

	var month = dtToday.getMonth() + 1;
	var day = dtToday.getDate();
	var year = dtToday.getFullYear();
	if (month < 10)
		month = '0' + month.toString();
	if (day < 10)
		day = '0' + day.toString();

	var maxDate = year + '-' + month + '-' + day
	$('#Date').attr('min', maxDate);
});