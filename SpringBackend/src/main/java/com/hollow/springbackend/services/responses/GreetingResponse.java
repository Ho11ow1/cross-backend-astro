package com.hollow.springbackend.services.responses;

public class GreetingResponse implements IResponse
{
    private final String message;

    public GreetingResponse(String message) { this.message = message; }

    public String getMessage() { return message; }
}
