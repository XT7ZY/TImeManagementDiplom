jQuery(document).ready(function () {
	jQuery('.datetimepicker').datepicker({
		timepicker: true,
		language: 'ru',
		range: true,
		multipleDates: true,
		multipleDatesSeparator: " - "
	});
/*	jQuery("#add-event").submit(function () {
		alert("Submitted");
		var values = {};
		$.each($('#add-event').serializeArray(), function (i, field) {
			values[field.name] = field.value;
		});
		console.log(
			values
		);
	});*/
});

(function () {

	var b = [];
	$.ajax({

		type: 'GET',
		url: "/Home/GetEvents",
		success: function (data) {
			$.each(data, function (i, v) {
				b.push({
					title: v.employer.name + " " + v.employer.lastName,
					description: v.employerId,
					start: moment(v.eventDay),
					className: 'fc-bg-default',
					allDay: true
				});
			})

		},
		error: function (error) {
			alert('failed');
		}
	})
	'use strict';
	// ------------------------------------------------------- //
	// Calendar
	// ------------------------------------------------------ //
	jQuery(function () {
		// page is ready
		jQuery('#calendar').fullCalendar({

			locale: 'ru',
			themeSystem: 'bootstrap4',
			// emphasizes business hours
			businessHours: false,
			defaultView: 'month',
			// event dragging & resizing
			editable: false,
			defaultAllDay: true,
			// header
			header: {
				left: 'title',
				right: 'today prev,next'
			},
			events: b,

			eventRender: function (event, element) {
				if (event.icon) {
					element.find(".fc-title").prepend("<i class='fa fa-" + event.icon + "'></i>");
				}
			},
			dayClick: function () {
				jQuery('#modal-view-event-add').modal('show');
			},
			eventClick: function (event, jsEvent, view) {
				jQuery('.event-icon').html("<i class='fa fa-" + event.icon + "'></i>");
				jQuery('.event-title').html(event.title);
				jQuery('.event-body').html(event.description);
				jQuery('.eventUrl').attr('href', event.url);
				jQuery('#modal-view-event').modal('show');
			},
		})
	});

})(jQuery);


