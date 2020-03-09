$(function() {
				$('#form1').hide();
				var picker1 = $('#datetimepicker1').datetimepicker({
					format: 'YYYY-MM-DD',
					locale: moment.locale('zh-cn'),
					//minDate: '2016-7-1'
				});
				var picker2 = $('#datetimepicker2').datetimepicker({
					format: 'YYYY-MM-DD',
					locale: moment.locale('zh-cn')
				});
				//动态设置最小值
				picker1.on('dp.change', function(e) {
					picker2.data('DateTimePicker').minDate(e.date);
				});
				//动态设置最大值
				picker2.on('dp.change', function(e) {
					picker1.data('DateTimePicker').maxDate(e.date);
				});
			});
			$('#datetimepicker1').datetimepicker({
				format: 'YYYY-MM-DD',
				locale: moment.locale('zh-cn'),
				defaultDate: "2020-1-1"
			});
			$('#datetimepicker2').datetimepicker({
				format: 'YYYY-MM-DD',
				locale: moment.locale('zh-cn'),
				defaultDate: "2030-1-1"
			});
