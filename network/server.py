from subprocess import Popen
from threading import Thread
from collections import namedtuple

import nacl
from nacl import signing
from gevent.server import StreamServer
from gevent import sleep

key = signing.SigningKey.generate()

id_proof = key.sign(key.verify_key.encode()) # I know this can be copied

MAX_MESSAGE_SIZE_BYTES = 10 * 1000 * 100


def extract_command(raw: bytes):
    return namedtuple('command_and_data', [raw[0], raw[0:]])


def handle(socket, address):
    def perform_handshake() -> bytes:  # Get the peer's ID
        handshake = socket.recv(96)

        verify = signing.VerifyKey(handshake[64:])
        try:
            if verify.verify(handshake) == handshake[64:]:
                socket.send(id_proof)
            else:
                socket.send(b"Handshake failed: did not sign key")
                raise nacl.exceptions.BadSignatureError
        except nacl.exceptions.BadSignatureError:
            socket.send(b"Handshake failed: bad sig")
            raise
    peer_id = perform_handshake()
    payload = socket.recv(MAX_MESSAGE_SIZE_BYTES)


server = StreamServer(('127.0.0.1', 1234), handle) # creates a new server

def show_port(server):
    sleep(1)
    print(f"Running on {server.server_port}")
Thread(target=show_port, args=[server], daemon=True).start()
server.serve_forever()
