"""
This script runs the application using a development server.
It contains the definition of routes and views for the application.
"""

from flask import Flask
import yaml
import os

app = Flask(__name__)

# Make the WSGI interface available at the top level so wfastcgi can get it.
wsgi_app = app.wsgi_app


@app.route('/')
def hello():
    """Renders a sample page."""
    return "Hola HydraBoot!"

@app.route('/<serviceName>')
def services(serviceName):
    my_path = os.path.abspath(os.path.dirname(__file__))
    path = os.path.join(my_path, "./config/boot.yml")
    with open(path, encoding="utf8", errors='ignore') as file:
        config = yaml.load(file, Loader=yaml.FullLoader)
    return config["services"][serviceName]

if __name__ == '__main__':
   
    HOST = os.environ.get('SERVER_HOST', '0.0.0.0')
    try:
        PORT = int(os.environ.get('SERVER_PORT', '1000'))
    except ValueError:
        PORT = 1000
    app.run(HOST, PORT)
