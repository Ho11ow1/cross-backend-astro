package com.hollow.springbackend.controllers;

import org.springframework.web.bind.annotation.*;
import com.hollow.springbackend.services.TestService;
import com.hollow.springbackend.services.responses.IResponse;

@RestController
@RequestMapping("/api")
public class TestController
{
    private final TestService _testService;

    public TestController(TestService testService)
    {
        _testService = testService;
    }

    @GetMapping(value = "/greet/{name}", produces = "application/json")
    public IResponse greet(@PathVariable String name)
    {
        return _testService.getGreeting(name);
    }
}
