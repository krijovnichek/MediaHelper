var express = require('express');
var app = express();
var fs = require('fs');


var filePath = ""

app.use(function (request, res) {
	res.sendFile('data.xml' , { root : __dirname});
});
app.listen(3000, function () {
  console.log('Example app listening on port 3000!');
});