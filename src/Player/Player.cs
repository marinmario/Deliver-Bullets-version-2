using Godot;
using System;

public class Player : KinematicBody2D
{
     [Export]
    int maxSpeed = 400;
    [Export]
    int acceleration = 500;
    [Export]
    int friction = 1000;
    Vector2 velocity;


    public override void _Process(float delta)
    {
        Vector2 motionVector;
        motionVector.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        motionVector.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");

        if (motionVector != Vector2.Zero)
            velocity = velocity.MoveToward(motionVector * maxSpeed, acceleration * delta);
        else 
            velocity = velocity.MoveToward(Vector2.Zero, friction * delta);

        velocity = MoveAndSlide(velocity);
    }

}
