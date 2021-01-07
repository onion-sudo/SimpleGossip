import socket

from nacl.signing import VerifyKey, SigningKey
import nacl



def gossip_client(host, port, iointerface_socket, our_key):


    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((host, port))
        s.sendall(our_key.sign(our_key.verify_key.encode()))
        their_handshake = s.recv(96)

        verify = signing.VerifyKey(their_handshake[64:])
        try:
            if verify.verify(their_handshake) == their_handshake[64:]:
                socket.send(id_proof)
            else:
                socket.send(b"Handshake failed: did not sign key")
                raise nacl.exceptions.BadSignatureError
        except nacl.exceptions.BadSignatureError:
            socket.send(b"Handshake failed: bad sig")
            raise
    

