const swaggerAutogen = require('swagger-autogen')();
2
const outputFile = './swagger/swagger_output.json';
const endpointsFiles = ['./index.js'];

swaggerAutogen(outputFile, endpointsFiles);