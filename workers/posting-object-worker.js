function messageHandler(e) {
    var args = e.data;
    if (args.command === 'start') {
        args.message = 'Your value is: ' + args.value;
        postMessage(args);
    }
}

addEventListener('message', messageHandler, true);
