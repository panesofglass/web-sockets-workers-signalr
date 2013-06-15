function messageHandler(e) {
    postMessage('Worker says, "' + e.data + '"');
}

addEventListener('message', messageHandler, true);
