package com.hollow.springbackend.services;

import com.hollow.springbackend.services.responses.GreetingResponse;
import com.hollow.springbackend.services.responses.IResponse;
import org.springframework.stereotype.Service;

@Service
public class TestService
{
    public IResponse getGreeting(String name)
    {
        return new GreetingResponse("Hello " + name);
    }
}
