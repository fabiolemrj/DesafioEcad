import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
let MusicsService = class MusicsService {
    constructor(http) {
        this.http = http;
        this.url = "http://localhost:5000/v1/musicsbyname";
    }
    getMusic() {
        return this.http.get(this.url);
    }
    ;
    getMusicName(id) {
        let _id = " ";
        if (id == "") {
            alert('');
            _id = id;
        }
        const _url = `${this.url}/${_id}`;
        return this.http.get(_url);
    }
    ;
};
MusicsService = tslib_1.__decorate([
    Injectable({
        providedIn: 'root'
    })
], MusicsService);
export { MusicsService };
//# sourceMappingURL=musics.service.js.map