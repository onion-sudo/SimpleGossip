from uuid import uuid4
import os
from subprocess import Popen, PIPE
from base64 import b64encode
import socket
from time import sleep

from nacl.signing import SigningKey

import client, server


def get_uuid(): return str(uuid())

backend_comm = {}
transports = []

key = SigningKey.generate()

project = os.path.dirname(os.path.realpath(__file__)) + "/../iointerface/"


with Popen(
        ["dotnet", "run", "--project", 
        project, 
        b64encode(
            key.verify_key.encode())], stdout=PIPE) as proc:
    for line in iter(proc.stdout.readline, b''):
        line = line.decode('utf-8')
        if line.startswith("Waiting"):
            break
    # Connect to IOInterface, read events
    with socket.socket(
            socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect(
            ("127.0.0.1", 13010))
        s.sendall(
            int(0).to_bytes(1, byteorder="little"))
        print(s.recv(1000))
        server.gossip_server()
