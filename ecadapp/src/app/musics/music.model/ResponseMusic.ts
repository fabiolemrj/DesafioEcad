import { Music } from '../music.model';

export interface ResponseMusic {
    success: boolean;
    message: string;
    data: Music[];
}
