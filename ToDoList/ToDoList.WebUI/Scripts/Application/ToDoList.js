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


var ajax_call = function () {
	$("#addModal").empty();
	$.ajax({
		url: "/Home/Trigger",
		dataType: "json",
		type: "post",
		processData: false,
		contentType: false,
		success: function (data) {
			$(data).each(function (i) {
				var date = data[i].Date;
				var split = date.split('(');
				var split1 = split[1].split(')');
				var date_ob = new Date(parseInt(split1[0]));
				var year = date_ob.getFullYear();
				var month = ("0" + (date_ob.getMonth() + 1)).slice(-2);
				var date = ("0" + date_ob.getDate()).slice(-2);
				$("#addModal").append("<div class='modal' id='" + data[i].Id + "'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><h4 class='modal-title'>TO DO </h4><button type='button' class='close' data-dismiss='modal'>&times;</button></div><div class='modal-body'><div class='row'><div class='col-md-6'><div class='form-group'><input type='text' class='form-control' value='" + data[i].Title + "' /><input type='text' class='form-control' value='" + data[i].Content + "' /><input type='text' class='form-control' value='" + date + '.' + month + '.' + year + "' /><input type='time' class='form-control' value='" + data[i].Time.Hours + ':' + data[i].Time.Minutes + "' /></div></div></div></div><div class='modal-footer'><button type='button' class='btn btn-danger' data-dismiss='modal'>Close</button></div></div></div></div>");

				$("#" + data[i].Id).modal();

			});
		}
	})
};
$(function () {
	var interval = 1000 * 60 * 1;
	setInterval(ajax_call, interval);
});
