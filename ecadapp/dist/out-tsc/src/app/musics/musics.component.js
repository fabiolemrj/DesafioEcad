import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let MusicsComponent = class MusicsComponent {
    constructor(musicservice) {
        this.musicservice = musicservice;
    }
    ngOnInit() {
        this.musicservice.getMusic().subscribe(res => this.responseMusics = res);
    }
    pesquisar(id) {
        this.musicservice.getMusicName(id).subscribe(res => this.responseMusics = res);
    }
};
MusicsComponent = tslib_1.__decorate([
    Component({
        selector: 'app-musics',
        templateUrl: './musics.component.html',
        styleUrls: ['./musics.component.css']
    })
], MusicsComponent);
export { MusicsComponent };
//# sourceMappingURL=musics.component.js.map