/* Function for JSFetch Patch */
/* Adam - Generate Graph on fetched data */
function JSFetchGraph(GRAPH) {
	if (GRAPH) {
		var ctx = document.getElementById(GRAPH);
		ctx.height = 150;

		if (GRAPH == "GRAPH-TL") {
			/* Tools - GitHub Commits - Bar Graph */
			var myChart = new Chart(ctx, {
				type: 'bar',
				data: {
					labels: ['Adam', 'Channon', 'Daniel', 'Jorge', 'Madeleine', 'Samuel'],
					datasets: [{
						label: '# of Commits',
						barPercentage: 1,
						minBarLength: 2,
						data: [149, 19, 29, 5, 0, 27],
						backgroundColor: [
							'rgba(255, 99, 132, 0.2)',
							'rgba(54, 162, 235, 0.2)',
							'rgba(255, 206, 86, 0.2)',
							'rgba(75, 192, 192, 0.2)',
							'rgba(153, 102, 255, 0.2)',
							'rgba(255, 159, 64, 0.2)'
						],
						borderColor: [
							'rgba(255, 99, 132, 1)',
							'rgba(54, 162, 235, 1)',
							'rgba(255, 206, 86, 1)',
							'rgba(75, 192, 192, 1)',
							'rgba(153, 102, 255, 1)',
							'rgba(255, 159, 64, 1)'
						],
						borderWidth: 1
					}]
				},
				options: {
					scales: {
						yAxes: [{
							ticks: {
								beginAtZero: true
							}
						}]
					}
				}
			});

		} else if (GRAPH == "GRAPH-CP") {
			/* Career Path - Radar Graph #1 */
			var data = {
				labels: ["SQL", "Java/JavaScript", "MS Windows","SAP", "Business Management/Analysis", "Graphic Design", "Building Relationships", "Linux" , "Tech Support","Costumer Service"],
				datasets: [
					{
						label: "Adam",
						backgroundColor: 'rgba(255, 99, 132, 0.2)',
						borderColor: 'rgba(255, 99, 132, 1)',
						pointBackgroundColor: 'rgba(255, 99, 132, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 'rgba(255, 99, 132, 1)',
						data: [10, 10, 10, 5, 4, 4, 5, 10, 4, 4]
					},
					{
						label: "Channon",
						backgroundColor: 'rgba(54, 162, 235, .2)',
						borderColor: 'rgba(54, 162, 235, 1)',
						pointBackgroundColor: 'rgba(54, 162, 235, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 'rgba(54, 162, 235, 1)',
						data: [9, 10, 8, 5, 5, 1, 5, 8, 8, 5]
					},
					{
						label: "Madeleine",
						backgroundColor: 	'rgba(153, 102, 255, 0.2)',
						borderColor:	'rgba(153, 102, 255, 1)',
						pointBackgroundColor:	'rgba(153, 102, 255, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 	'rgba(153, 102, 255, 1)',
						data: [1, 5, 5, 1, 1, 1, 7, 1, 10, 10]
					},
					{
						label: "Samuel",
						backgroundColor: 	'rgba(255, 159, 64, 0.2)',
						borderColor: 	'rgba(255, 159, 64, 1)',
						pointBackgroundColor: 	'rgba(255, 159, 64, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 	'rgba(255, 159, 64, 1)',
						data: [10, 9, 9, 10, 8, 5, 8, 7, 6, 9]
					},
					{
						label: "Jorge",
						backgroundColor: 	'rgba(75, 192, 192, .2)',
						borderColor:	'rgba(75, 192, 192, 1)',
						pointBackgroundColor: 	'rgba(75, 192, 192, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 	'rgba(75, 192, 192, 1)',
						data: [5, 2, 9, 1, 9, 1, 7, 1, 7, 9]
					},
					{
						label: "Daniel",
						backgroundColor: 	'rgba(255, 206, 86, 0.2)',
						borderColor: 	'rgba(255, 206, 86, 1)',
						pointBackgroundColor: 	'rgba(255, 206, 86, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 	'rgba(255, 206, 86, 1)',
						data: [10, 1, 10, 1, 5, 1, 8, 1, 9, 8]
					}
				]
			};
			var options = {
					tooltips: {
						mode: 'label'
					},
				};
			var myChart = new Chart(ctx, {
				type: 'radar',
				data: data,
				options: options
			});

		} else if (GRAPH =="GRAPH-CP2") {
			/* Career Path - Radar Graph #2 */
			var data = {
			labels: ["Communication", "Problem Solving", "Organizational skills", "Writing inc Coding", "Teamwork", "Troubleshooting", "Planning" , "Detail-Orientated","Creativity","Research"],
			datasets: [
					{
						label: "Adam",
						backgroundColor: 'rgba(255, 99, 132, 0.2)',
						borderColor: 'rgba(255, 99, 132, 1)',
						pointBackgroundColor:'rgba(255, 99, 132, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 'rgba(255, 99, 132, 1)',
						data: [8, 10, 10, 10, 10, 10, 10, 10, 5, 8]
					},
					{
						label: "Channon",
						backgroundColor: 'rgba(54, 162, 235, 0.2)',
						borderColor: 'rgba(54, 162, 235, 1)',
						pointBackgroundColor: 'rgba(54, 162, 235, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 'rgba(54, 162, 235, 1)',
						data: [8, 10, 9, 10, 6, 8, 6, 8, 10, 8]
					},
					{
						label: "Madeleine",
						backgroundColor:	'rgba(153, 102, 255, 0.2)',
						borderColor:	'rgba(153, 102, 255, 1)',
						pointBackgroundColor:	'rgba(153, 102, 255, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor:	'rgba(153, 102, 255, 1)',
						data: [10, 10, 9, 5, 9, 10, 9, 4, 2, 7]
					},
					{
						label: "Samuel",
						backgroundColor: 	'rgba(255, 159, 64, 0.2)',
						borderColor: 	'rgba(255, 159, 64, 1)',
						pointBackgroundColor:	'rgba(255, 159, 64, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor:	'rgba(255, 159, 64, 1)',
						data: [10, 8, 8, 8, 9, 8, 8, 8, 7, 9]
					},
					{
						label: "Jorge",
						backgroundColor: 	'rgba(75, 192, 192, 0.2)',
						borderColor:	'rgba(75, 192, 192, 1)',
						pointBackgroundColor: 	'rgba(75, 192, 192, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor: 	'rgba(75, 192, 192, 1)',
						data: [8, 9, 9, 5, 6, 9, 9, 8, 8, 8]
					},
					{
						label: "Daniel",
						backgroundColor: 	'rgba(255, 206, 86, 0.2)',
						borderColor:	'rgba(255, 206, 86, 1)',
						pointBackgroundColor: 	'rgba(255, 206, 86, 1)',
						pointBorderColor: "#fff",
						pointHoverBackgroundColor: "#fff",
						pointHoverBorderColor:	'rgba(255, 206, 86, 1)',
						data: [10, 8, 9, 8, 8, 9, 10, 5, 6, 3]
					}
				]
			};
			var options = {
					tooltips: {
						mode: 'label'
					},
				};
			var myChart = new Chart(ctx, {
				type: 'radar',
				data: data,
				options: options
			});

		} else if (GRAPH == "GRAPH-ID") {
			/* Industry Data - Bar Graph */
			var mixedChart = new Chart(ctx, {
			type: 'bar',
			data: {
				datasets: [{
						label: 'Burning Glass Ranking',
						data: [10, 9, 8.5, 7.6, 7.5, 7.6, 7.2, 7.3, 6.5, 6.75, 6],
						backgroundColor: 'rgba(255,255,0,0)',
						borderColor: 'rgba(255,255,0,0.75)',
						pointBackgroundColor: 'rgba(255,255,0,0.75)',
						// this dataset is drawn below
						type: 'line',
						order: 1
					}, {
						label: 'Adam',
						backgroundColor: 'rgba(255, 99, 132, 0.8)',
						borderColor: 'rgba(255, 99, 132, 1)',
						data: [10, 10, 10, 5 ,4, 4, 5, 10 , 4, 4],
						// this dataset is drawn on top
						order: 2
					}, {
						label: 'Channon',
						backgroundColor: 'rgba(54, 162, 235, 0.8)',
						borderColor:	'rgba(54, 162, 235, 1)',
						data: [9, 10, 8, 5,5, 1, 5, 8, 8, 5],
						order: 2
					}, {
						label: 'Madeleine',
						backgroundColor:	'rgba(153, 102, 255, 0.8)',
						borderColor:	'rgba(153, 102, 255, 1)',
						data: [1, 5, 5, 1,1, 1, 7, 1 , 10, 10],
						order: 2
					}, {
						label: 'Samuel',
						backgroundColor: 	'rgba(255, 159, 64, 0.8)',
						borderColor:	'rgba(255, 159, 64, 1)',
						data: [10, 9, 9,10, 8, 5, 8, 6 , 6, 10],
						order: 2
					}, {
						label: 'Jorge',
						backgroundColor: 'rgba(75, 192, 192, 0.8)',
						borderColor:'rgba(75, 192, 192, 1)',
						data: [5, 2, 9, 1,9, 1, 7, 1 , 7, 9],
						order: 2
					}, {
						label: 'Daniel',
						backgroundColor:	'rgba(255, 206, 86, 0.8)',
						borderColor:	'rgba(255, 206, 86, 1)',
						data: [10, 1, 10, 1,5, 1, 8, 6, 6, 9],
						order: 2
					}],
					labels: ['SQL', 'Java/JavaScript', 'MS Windows','SAP', 'Business Management/Analysis', 'Graphic Design', 'Building Relationships', 'Linux' , 'Tech Support','Costumer Service']
				},
			});
			
		} else if (GRAPH == "GRAPH-ID2") {
			/* Industry Data - Bar Graph 2 */
			var mixedChart = new Chart(ctx, {
				type: 'bar',
				data: {
					datasets: [{
						label: 'Burning Glass Ranking',
						data: [10, 6.2, 6.2, 6.2, 5.9, 5.6, 5.6, 5.2, 5, 5],
							backgroundColor: 'rgba(255,255,0,0)',
							borderColor: 'rgba(255,255,0,0.75)',
							pointBackgroundColor: 'rgba(255,255,0,0.75)',
							// this dataset is drawn below
							type: 'line',
							order: 1
						}, {
							label: 'Adam',
							backgroundColor: 'rgba(255, 99, 132, 0.8)',
							borderColor: 'rgba(255, 99, 132, 1)',
							data: [8, 10, 10, 10, 10, 10, 10 , 10, 5, 8],
							// this dataset is drawn on top
							order: 2
						}, {
							label: 'Channon',
							backgroundColor: 'rgba(54, 162, 235, 0.8)',
							borderColor:	'rgba(54, 162, 235, 1)',
							data: [8, 10, 9, 10, 6, 8, 6, 8, 10, 9],
							order: 2
						}, {
							label: 'Madeleine',
							backgroundColor:	'rgba(153, 102, 255, 0.8)',
							borderColor:	'rgba(153, 102, 255, 1)',
							data: [10, 10, 9, 5, 9, 10, 9 , 4, 2, 7],
							order: 2
						}, {
							label: 'Samuel',
							backgroundColor: 	'rgba(255, 159, 64, 0.8)',
							borderColor:	'rgba(255, 159, 64, 1)',
							data: [10, 8, 8, 8, 9, 8, 8 , 8, 7, 9],
							order: 2
						}, {
							label: 'Jorge',
							backgroundColor: 'rgba(75, 192, 192, 0.8)',
							borderColor:'rgba(75, 192, 192, 1)',
							data: [8, 9, 9, 5, 6, 9, 9 , 8, 8,8],
							order: 2
						}, {
							label: 'Daniel',
							backgroundColor:	'rgba(255, 206, 86, 0.8)',
							borderColor:	'rgba(255, 206, 86, 1)',
							data: [10, 8, 9, 8, 8, 9, 10 , 9, 5, 6, 3],
							order: 2
						}],
					labels: ['Communication', 'Problem Solving', 'Organizational skills', 'Writing inc Coding', 'Teamwork', 'Troubleshooting', 'Planning' , 'Detail-Orientated','Creativity','Research']
				},
			});
		} else {
		// Do Nothing
		}
	}
	return false;
}
