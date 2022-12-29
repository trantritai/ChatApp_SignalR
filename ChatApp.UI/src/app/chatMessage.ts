import { Guid } from "guid-typescript";
export class ChatMessage {
    text: string;
    connectionId: Guid;
    date: Date;

    constructor(text: string, connectionId: Guid, date: Date) {
        this.text = text;
        this.connectionId = connectionId;
        this.date = date;
    }

}