
export interface RespGetMusic {
    
    data: ReqUpdateMusic;
}


export interface ReqUpdateMusic{
    id: string;
    code: string;
    name: string;
    genre: number;
}

export interface RespUpdateMusic {
    success: boolean;
    message: string;
    data: ReqUpdateMusic;
}

