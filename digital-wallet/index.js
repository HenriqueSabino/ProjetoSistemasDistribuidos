const express = require("express");
const Carteira = require("./models/carteira");
const app = express();
const port = 3000;
const routes = require('./routes/mainRouter')
const swaggerUi = require('swagger-ui-express');
const swaggerFile = require('./swagger/swagger_output.json');

app.use('/docs', swaggerUi.serve, swaggerUi.setup(swaggerFile));
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.use(
  express.urlencoded({
    extended: true,
  })
);
app.get("/", (req, res) => {
  res.json({ message: "App is working" });
});

app.use("/api", routes)

app.use((err, req, res, next) => {
    const statusCode = err.statusCode || 500;
    console.error(err.message, err.stack);
    res.status(statusCode).json({ message: err.message });
    return;
});

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`);
});

// (async () => {
//     const database = require('./db.js');
//     const Carteira = require('./models/carteira');
 
//     try {
//         const resultado = await database.sync();
//         console.log(resultado);
 
//         const resultadoCreate = await Carteira.create({
//             userId: 'user1',
//             balance: 1000
//         })
//         console.log(resultadoCreate);

//         const resultadoCreate2 = await Carteira.create({
//             userId: 'user2',
//             balance: 900
//         })
//         console.log(resultadoCreate2);

//         const resultadoCreate3 = await Carteira.create({
//             userId: 'user3',
//             balance: 0
//         })
//         console.log(resultadoCreate3);

//         const resultadoCreate4 = await Carteira.create({
//             userId: 'user4',
//             balance: 100
//         })
//         console.log(resultadoCreate4);

//         const resultadoCreate5 = await Carteira.create({
//             userId: 'user5',
//             balance: 50
//         })
//         console.log(resultadoCreate5);
//     } catch (error) {
//         console.log(error);
//     }
// })();