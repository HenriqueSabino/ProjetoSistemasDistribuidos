var path = require('path');
var grpc = require('@grpc/grpc-js');
var protoLoader = require('@grpc/proto-loader');
const walletProto = protoLoader.loadSync(path.resolve(__dirname, '../wallet.proto'))
var routeguide = grpc.loadPackageDefinition(walletProto);
var client = new routeguide.WalletService('localhost:50051', grpc.credentials.createInsecure());

    
module.exports = client