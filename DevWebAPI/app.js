'use strict';
var express = require('express');
var bodyParser = require('body-parser');
var http = require('http');
var fs = require('fs');
var app = express();

const CONF = {
    publicUrl: "https://indev.themeldingwars.com",
    privateUrl: "127.0.0.1",
    gameServer: "indev.themeldingwars.com:25000",
    port: 7171,
    fullUrl: function () { return `${CONF.publicUrl}`; }
};

const hosts =
{
    clientapi_host:                 CONF.fullUrl() + "/clientapi",
    frontend_host:                  CONF.fullUrl() + "/frontend_host",
    rhsigscan_host:                 CONF.fullUrl() + "/rhsigscan_host",
    store_host:                     CONF.fullUrl() + "/store_host",
    chat_server:                    CONF.fullUrl() + "/chat_server",
    market_host:                    CONF.fullUrl() + "/market_host",
    replay_host:                    CONF.fullUrl() + "/replay_host",
    web_accounts_host:              CONF.fullUrl() + "/web_accounts_host",
    ingame_host:                    CONF.fullUrl() + "/ingame_host"
};

const LOGIN_DATA = {
    account_id: 42,
    can_login: true,
    is_dev: false,
    steam_auth_prompt: false,
    skip_precursor: true,
    cais_status: {
        state: "disabled",
        duration: 0,
        expires_at: 0
    },
    character_limit: 2,
    is_vip: false,
    vip_expiration: 0
};

const CHAR_DATA = require("./CharData").data;

const ORACLE_DATA = {
    "matrix_url": CONF.gameServer,
    "ticket": "UjX52MMObRnEtgZe1pjrRFS6iRz3t7aR69fgLdzwxJQumRt7mhpNqPkejXFT\nBf3H2a5bZI/zQhO4CvKj+Z5Jctk4yMU4mgPzHiN+FJb+CiKvcQGhjNqAskD3\nalZQkZ/N+v1dSC25DLGR0Ky/3V1fsw0Y2bh+xsAgoKg1BkIJHiltTW3spuVT\nUd8fo9oLG0UzhCWP/NNIfcGX+Ur/e7UYxoUCiwHhRH3673Q1TtCoociHwvpj\np4QExjp3Cd2LTolR00l8zYAvodMBPJyOuMf/BB8KDkoP8hnpNh8ZIpmxeWXr\ndZ2R5r8hSAIht3uNMZd/Wa3ewQgqwj/womRSCqhSOpdPFebbgI2TVnth7IA0\nZq4EvvI436cBOc1P1wVfvFW6EUebqCzfIxn63UYQWXc1+KnCjLh9r4l60xm3\n6Yes+7zJwS2r02UslF+QgpUuXJw4I4h7OK+YRrHnOFtiKOUnC3hJMUbY6yZA\nR6/ZdfvBLt9XlA==\n",
    "datacenter": "localhost",
    "operator_override": {
        "ingame_host": hosts.ingame_host,
        "clientapi_host": hosts.clientapi_host
    },
    "session_id": "8360c86c-a3d0-11e4-9e16-c074c1266b6d",
    "hostname": "localhost",
    "country": "GB"
};

// Set up the routes
app.listen(CONF.port, CONF.privateUrl, function () {
    for (let route in ROUTES) {
        app.all(route, ROUTES[route]);
    }

    app.all('/*', function (req, res, next) {
        console.log('Request for: ' + req.url);
        next();
    });
});

const ROUTES = {
    ["/check"]: function (Req, Res) {
        var data = JSON.stringify(hosts);
        Res.header("Content-Type", "application/json");
        Res.send(data);
    },

    // Login
    ["/clientapi/api/v2/accounts/login"]: function (Req, Res) {
        var data = JSON.stringify(LOGIN_DATA);
        Res.header("Content-Type", "application/json");
        Res.send(data);
    },

    // Char List
    ["/clientapi/api/v2/characters/list"]: function (Req, Res) {
        var data = JSON.stringify(CHAR_DATA);
        Res.header("Content-Type", "application/json");
        Res.send(data);
    },

    ["/clientapi/api/v1/oracle/ticket"]: function (Req, Res) {
        var data = JSON.stringify(ORACLE_DATA);
        Res.header("Content-Type", "application/json");
        Res.send(data);
    }
};