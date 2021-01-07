from uuid import uuid4
from subprocess import Popen

from . import client, server


def get_uuid(): return str(uuid())

backend_comm = {}
transports = []

# TODO full path to project
with Popen(
    ["dotnet run --project iointerface"], 
    stdout=PIPE, stderr=PIPE, stdin=PIPE) as backend:
        backend.poll()
