# QuantityMeasurementApp
## Overview

The Quantity Measurement App is a progressive, incremental project built to compare, convert, and perform arithmetic operations on measurable quantities such as length.

The application is developed step-by-step using clearly defined Use Cases (UCs).
Each use case introduces a focused piece of functionality while preserving backward compatibility and maintaining clean architecture.

The system evolves from simple equality checks to:

Cross-unit comparisons

Explicit unit conversions

Arithmetic operations with implicit and explicit result units

Flexible API design with immutability

The design emphasizes correctness, scalability, and test-driven validation.

## Project Goals

Build a clean and extensible Quantity Measurement API

Follow incremental development using structured use cases

Apply OOP principles and SOLID design practices

Maintain immutability of value objects

Ensure complete unit test coverage for each use case

Keep logic normalized using a consistent base unit

## Implemented Features (UC1 – UC7)
✅ UC1 – Basic Equality (Feet)

Compare two values in the same unit

Validate null, type, and reference equality

✅ UC2 – Equality with Inches

Compare feet and inches separately

Maintain object encapsulation and equality contracts

✅ UC3 – Generic Quantity Class (DRY Principle)

Refactor separate unit classes into a single QuantityLength

Introduce LengthUnit enum

Normalize values to a base unit (Feet)

✅ UC4 – Extended Unit Support

Added:

Yards

Centimeters

Enabled cross-unit equality across all supported length units

✅ UC5 – Unit Conversion API

Static Convert() method

Instance ConvertTo() method

Handles:

Cross-unit conversion

Same-unit conversion

Zero, negative, large values

NaN / Infinity validation

✅ UC6 – Addition (Implicit Target Unit)

Add two quantities

Result returned in unit of first operand

Cross-unit arithmetic supported

Immutability preserved

✅ UC7 – Addition (Explicit Target Unit)

Add two quantities with caller-specified result unit

Explicit control over output representation

Fully commutative

Precision-safe arithmetic

Supported Units (Length Category)

Feet

Inches

Yards

Centimeters

All units are normalized internally to a common base unit (Feet) for accurate arithmetic and comparison.

## Core Concepts Demonstrated

Value Object Pattern

Immutability

Base Unit Normalization

DRY Principle

Method Overloading

Enum-based Unit Management

Equality Contract Implementation

Floating-Point Precision Handling (Epsilon-based comparison)

Explicit vs Implicit API Design

Test-Driven Incremental Development

## Development Approach

Each use case:

Introduces a clearly defined feature

Adds dedicated NUnit test coverage

Preserves backward compatibility

Avoids duplication through refactoring

This ensures:

Clean incremental evolution

Stable architecture

High confidence through tests

Easy extension for future measurement categories

## Tech Stack

Language: C#

Framework: .NET

Testing Framework: NUnit

IDE: VS Code

CLI: .NET CLI
