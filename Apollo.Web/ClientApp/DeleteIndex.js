var fs = require('fs');
var fileName = '../wwwRoot/index.html'
fs.exists(fileName, (exists) => {
  if (exists) {
    console.error(fileName + ' file  exists');
    fs.unlink(fileName, function (err) {
      if (err) throw err;
      console.log(fileName + ' File deleted!');
    });
  } else {
    console.log(fileName + ' file does not exists');
  }

});
