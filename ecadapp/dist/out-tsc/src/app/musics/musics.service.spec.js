import { TestBed } from '@angular/core/testing';
import { MusicsService } from './musics.service';
describe('MusicsService', () => {
    beforeEach(() => TestBed.configureTestingModule({}));
    it('should be created', () => {
        const service = TestBed.get(MusicsService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=musics.service.spec.js.map