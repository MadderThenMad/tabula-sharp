﻿using System;
using System.Collections.Generic;
using System.Text;
using UglyToad.PdfPig.Core;
using Xunit;

namespace Tabula.Tests
{
	public class TestRuling
	{
		Ruling ruling = new Ruling(0, 0, 10, 10);

		[Fact]
		public void testGetWidth()
		{
			Assert.Equal(10f, ruling.getWidth(), 5);
		}

		[Fact]
		public void testGetHeight()
		{
			Assert.Equal(10f, ruling.getHeight(),5);
		}

		[Fact]
		public void testToString()
		{
			//Assert.Equal("class technology.tabula.Ruling[x1=0.000000 y1=0.000000 x2=10.000000 y2=10.000000]", ruling.ToString());
			Assert.Equal("Tabula.Ruling[x1=0 y1=0 x2=10 y2=10]", ruling.ToString());
		}

		[Fact]
		public void testEqualsOther()
		{
			Ruling other = new Ruling(0, 0, 11, 10);
			Assert.True(ruling.Equals(ruling));
		}

		[Fact]
		public void testEqualsDifferentInstance()
		{
			Assert.False(ruling.Equals("test"));
		}

		[Fact]
		public void testNearlyIntersects()
		{
			Ruling another = new Ruling(0, 0, 11, 10);

			Assert.True(ruling.nearlyIntersects(another));
		}


		[Fact]//	@Test(expected = UnsupportedOperationException.class)
		public void testGetPositionError()
		{
			Ruling other = new Ruling(0, 0, 1, 1);
			Assert.Throws<InvalidOperationException>(() => other.getPosition());
			//fail();
		}

		[Fact]// @Test(expected = UnsupportedOperationException.class)
		public void testSetPositionError()
		{
			Ruling other = new Ruling(0, 0, 1, 1);
			Assert.Throws<InvalidOperationException>(() => other.setPosition(5f));
			//fail();
		}

		[Fact]  //@Test(expected = UnsupportedOperationException.class)
		public void testsetPosition()
		{
			Assert.Throws<InvalidOperationException>(() => ruling.setPosition(0));
		}

		[Fact]  //@Test(expected = UnsupportedOperationException.class)
		public void testGetStartError()
		{
			Ruling other = new Ruling(0, 0, 1, 1);
			Assert.Throws<InvalidOperationException>(() => other.getStart());
			//fail();
		}

		[Fact]// @Test(expected = UnsupportedOperationException.class)
		public void testGetEndError()
		{
			Ruling other = new Ruling(0, 0, 1, 1);
			Assert.Throws<InvalidOperationException>(() => other.getEnd());
			//fail();
		}

		[Fact]// @Test(expected = UnsupportedOperationException.class)
		public void testSetEndError()
		{
			Ruling other = new Ruling(0, 0, 1, 1);
			Assert.Throws<InvalidOperationException>(() => other.setEnd(5f));
			//fail();
		}


		[Fact]
		public void testColinear()
		{
			//		Ruling another = new Ruling(0, 0, 500, 5);
			PdfPoint float1 = new PdfPoint(20, 20);
			PdfPoint float2 = new PdfPoint(0, 0);
			PdfPoint float3 = new PdfPoint(20, 0);
			PdfPoint float4 = new PdfPoint(0, 20);

			Assert.False(ruling.colinear(float1));
			Assert.True(ruling.colinear(float2));
			Assert.False(ruling.colinear(float3));
			Assert.False(ruling.colinear(float4));


		}

	}
}
