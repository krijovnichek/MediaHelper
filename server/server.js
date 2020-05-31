var express = require('express');
var app = express();
var fs = require('fs');


var filePath = ""

app.use(function (request, res) {
	res.sendFile('data.xml' , { root : __dirname});
});



app.get('/postxml', function(req, res){

  var file = fs.readFileSync(__dirname + '/data1.xml', 'binary');

  res.setHeader('Content-Length', file.length);
  res.write(file, 'binary');
  res.end();
});



app.listen(3000, function () {
  console.log('Example app listening on port 3000!');
});