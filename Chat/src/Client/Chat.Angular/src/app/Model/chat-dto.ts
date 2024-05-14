export interface ChatDTO {
    id: string;
    link: string;
    type: ChatType;
    createdDate: Date;
}

enum ChatType {
    OneToOne = 0,
    Group,
    Channel
}
