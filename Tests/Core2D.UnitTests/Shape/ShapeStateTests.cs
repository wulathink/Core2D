﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Xunit;

namespace Core2D.UnitTests
{
    public class ShapeStateTests
    {
        [Fact]
        public void Inherits_From_ObservableObject()
        {
            var target = new ShapeState();
            Assert.True(target is ObservableObject);
        }

        [Fact]
        public void Flags_On_Set_Notify_Events_Are_Raised()
        {
            var target = new ShapeState();
            var observer = new PropertyChangedObserver(target);

            target.Flags = ShapeStateFlags.Visible | ShapeStateFlags.Printable | ShapeStateFlags.Standalone;

            Assert.Equal(ShapeStateFlags.Visible | ShapeStateFlags.Printable | ShapeStateFlags.Standalone, target.Flags);
            Assert.Equal(10, observer.PropertyNames.Count);

            var propertyNames = new string[]
            {
                nameof(ShapeState.Flags),
                nameof(ShapeState.Default),
                nameof(ShapeState.Visible),
                nameof(ShapeState.Printable),
                nameof(ShapeState.Locked),
                nameof(ShapeState.Connector),
                nameof(ShapeState.None),
                nameof(ShapeState.Standalone),
                nameof(ShapeState.Input),
                nameof(ShapeState.Output)
            };

            Assert.Equal(propertyNames, observer.PropertyNames);
        }

        [Fact]
        public void Default_Property()
        {
            var target = new ShapeState();

            target.Default = true;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);

            target.Default = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void Visible_Property()
        {
            var target = new ShapeState();

            target.Visible = true;
            Assert.Equal(ShapeStateFlags.Visible, target.Flags);

            target.Visible = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void Printable_Property()
        {
            var target = new ShapeState();

            target.Printable = true;
            Assert.Equal(ShapeStateFlags.Printable, target.Flags);

            target.Printable = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void Locked_Property()
        {
            var target = new ShapeState();

            target.Locked = true;
            Assert.Equal(ShapeStateFlags.Locked, target.Flags);

            target.Locked = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void Connector_Property()
        {
            var target = new ShapeState();

            target.Connector = true;
            Assert.Equal(ShapeStateFlags.Connector, target.Flags);

            target.Connector = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void None_Property()
        {
            var target = new ShapeState();

            target.None = true;
            Assert.Equal(ShapeStateFlags.None, target.Flags);

            target.None = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void Standalone_Property()
        {
            var target = new ShapeState();

            target.Standalone = true;
            Assert.Equal(ShapeStateFlags.Standalone, target.Flags);

            target.Standalone = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void Input_Property()
        {
            var target = new ShapeState();

            target.Input = true;
            Assert.Equal(ShapeStateFlags.Input, target.Flags);

            target.Input = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void Output_Property()
        {
            var target = new ShapeState();

            target.Output = true;
            Assert.Equal(ShapeStateFlags.Output, target.Flags);

            target.Output = false;
            Assert.Equal(ShapeStateFlags.Default, target.Flags);
        }

        [Fact]
        public void Parse_Shape_StateFlags_String()
        {
            var result = ShapeState.Parse("Visible, Printable, Standalone");

            Assert.Equal(ShapeStateFlags.Visible | ShapeStateFlags.Printable | ShapeStateFlags.Standalone, result.Flags);
        }

        [Fact]
        public void ToString_Should_Return_Flags_String()
        {
            var target = new ShapeState()
            {
                Flags = ShapeStateFlags.Visible | ShapeStateFlags.Printable | ShapeStateFlags.Standalone
            };

            Assert.Equal("Visible, Printable, Standalone", target.ToString());
        }
    }
}