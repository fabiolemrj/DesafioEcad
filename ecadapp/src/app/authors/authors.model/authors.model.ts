export interface Author{
    id: string;
    code: string;
    name: string;
    category: string;
}

export interface ResponseAuthor {
    success: boolean;
    message: string;
    data: Author[];
}

