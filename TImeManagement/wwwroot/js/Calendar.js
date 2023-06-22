jQuery(document).ready(function () {
	jQuery('.datetimepicker').datepicker({
		timepicker: true,
		language: 'ru',
		range: true,
		multipleDates: true,
		multipleDatesSeparator: " - "
	});

});

(function () {

	var b = [];

	$.ajax({
		type: 'GET',
		url: "/Events/GetEvents",
		success: function (data) {
			$.each(data, function (i, v) {
				b.push({
					eventId: v.id,
					title: v.employer.lastName + " " + v.employer.name,
					description: v.eventDay,
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

	jQuery(function () {
		var selctedEvent = null;
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
				selctedEvent = event.eventId;
				jQuery('.event-icon').html("<i class='fa fa-" + event.icon + "'></i>");
				jQuery('.event-title').html(event.title);
				jQuery('.event-body').html(event.description);
				jQuery('.eventUrl').attr('href', event.url);
				jQuery('#modal-view-event').modal('show');
			},
		})

		$('#btnDeleteEvent').click(function () {
			if (selctedEvent != null && confirm('Удалить?')) {
				$.ajax({
					type: 'POST',
					url: '/events/DeleteEvent',
					data: { 'eventId': selctedEvent },
					success: function (status) {
						if (status) {
							alert('Удалено');
							jQuery('#modal-view-event').modal('hide');
						}
					},
					error: function () {
						alert('Ошибка');
					}
				})
			}
		})
	});
})(jQuery); jQuery(document).ready(function () {
	jQuery('.datetimepicker').datepicker({
		timepicker: true,
		language: 'ru',
		range: true,
		multipleDates: true,
		multipleDatesSeparator: " - "
	});

});
