const client = require('./client-grpc')

let newOrder = {
    userId: 'testeUID2',
    price: 2.112,
}
client.buy(newOrder, (error, orderResponse) => {
    if (!error) {
        console.log(orderResponse)
    } else {
        console.error(error)
    }
})