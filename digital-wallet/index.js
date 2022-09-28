const grpc = require('@grpc/grpc-js')
const protoLoader = require('@grpc/proto-loader')
const path = require('path')
const walletProto = protoLoader.loadSync(path.resolve(__dirname, 'wallet.proto'))
const WalletDefinition = grpc.loadPackageDefinition(walletProto)

function Buy (call, callBack) {
    console.log('Hit buy with price ' + call.request.price)
    callBack(null, {userId: call.request.userId, success: true, error: ''})
}

const server = new grpc.Server();

server.addService(WalletDefinition.WalletService.service, { Buy })

server.bindAsync('127.0.0.1:50051', grpc.ServerCredentials.createInsecure(), () => {
    server.start()
})
console.log('Server running at http://127.0.0.1:50051')